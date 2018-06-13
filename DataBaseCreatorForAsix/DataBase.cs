using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace DataBaseCreatorForAsix
{
    /// <summary>
    /// Represents Asix Evo 9 tags database (MS Access .mdb file).
    /// </summary>
    class DataBase
    {
        /// <summary>
        /// Event raised when progress in saving tags to the database is made.
        /// </summary>
        public event EventHandler<ProgressChangedArgs> ProgressChanged;

        /// <summary>
        /// Event raised when there is new info to show in the log.
        /// </summary>
        public event EventHandler<LogEventArgs> NewEvent;

        /// <summary>
        /// Raises ProgressChanged event.
        /// </summary>
        public void OnProgressChanged(ProgressChangedArgs progressChangedArgs)
        {
            ProgressChanged?.Invoke(this, progressChangedArgs);
        }

        /// <summary>
        /// Raises NewEvent event.
        /// </summary>
        public void OnNewEvent(LogEventArgs logEventArgs)
        {
            NewEvent?.Invoke(this, logEventArgs);
        }

        int allTagsCount; //fields for showing tags' statistics
        int tagsAdded;
        int tagsExisted;

        /// <summary>
        /// Database connection.
        /// </summary>
        OleDbConnection conn;

        /// <summary>
        /// Creates backup for existing database file.
        /// </summary>
        public void Backup(string sourcePath)
        {
            string extentsion = Path.GetExtension(sourcePath);
            string fileName = Path.GetFileNameWithoutExtension(sourcePath);
            string directory = Path.GetDirectoryName(sourcePath);
            string newFileName = String.Format(fileName+"_{0:yyMMddhhmmss}"+extentsion, DateTime.Now); //the current date is added

            try
            {
                File.Copy(sourcePath, Path.Combine(directory, newFileName), true);
                OnNewEvent(new LogEventArgs("Database backup created"));
            }
            catch(Exception ex)
            {
                OnNewEvent(new LogEventArgs("Cannot create database backup " + ex));
            }
        }

        /// <summary>
        /// Most important method - adds tags to the database
        /// </summary>
        public void Create(string fileName, bool overwrite, List<Tag> tags)
        {
            Stopwatch stopwatch = new Stopwatch(); //counting operation time
            stopwatch.Start();

            Backup(fileName); //doing the backup before modifying database 

            try
            {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + fileName);
                conn.Open(); //opening connection to the database

                if (overwrite)  //deleting existing records before adding tags
                {
                    using (OleDbCommand cmd = new OleDbCommand("DELETE * FROM Items", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                allTagsCount = tags.Count - 1; //initializing counting fields
                tagsAdded = 0;
                tagsExisted = 0;

                for (int i = 0; i < tags.Count; i++)
                {
                    bool itemExists = false;
                    OleDbDataReader reader;
                    if (!overwrite)  //checking if the tag is already in the database
                    {
                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Items` WHERE Name='" + tags[i].Name + "'", conn))
                        {
                            reader = cmd.ExecuteReader();
                        }
                        DataTable queryResult = new DataTable();
                        queryResult.Load(reader);
                        if (queryResult.Rows.Count > 0) { itemExists = true; }
                    }

                    if (!itemExists) //if the tag doesn't exist, adds new tag
                    {
                        string values = string.Format(
                            $"'{tags[i].Name}'," +
                            $"'{tags[i].Address}'," +
                            $"'{tags[i].ConversionFunction}'," +
                            $"'{tags[i].Archive}'," +
                            $"'{tags[i].ArchivingParameters}'," +
                            $"'{tags[i].Format}'," +
                            $"'{tags[i].Unit}'," +
                            $"'{tags[i].DisplayRangeFrom}'," +
                            $"'{tags[i].DisplayRangeTo}'," +
                            $"'{tags[i].MeasurementRangeFrom}'," +
                            $"'{tags[i].MeasurementRangeTo}'," +
                            $"'{tags[i].StateNames}'," +
                            $"'{tags[i].Group2}'," +
                            $"'{tags[i].Group3}'," +
                            $"'{tags[i].Group4}'," +
                            $"'{tags[i].Group5}'," +
                            $"'{tags[i].ImportIgnored}'," +
                            $"'{tags[i].Description}'," +
                            $"'{tags[i].Channel}'," +
                            $"'{tags[i].ElementsCount}'," +
                            $"'{tags[i].SampleRate}'," +
                            $"'{tags[i].Group1}'");

                        using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Items (Name, Address, ConversionFunction, Archive, ArchivingParameters, Format, Unit, DisplayRangeFrom, DisplayRangeTo, MeasurementRangeFrom,  MeasurementRangeTo, StateNames, Group2, Group3, Group4, Group5, ImportIgnored, Description, Channel, ElementsCount, SampleRate, Group1) VALUES (" + values + ")", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        tags[i].IsAdded = true;
                        tagsAdded++;
                    }
                    else
                    {
                        tagsExisted++;
                    }


                    OnProgressChanged(new ProgressChangedArgs(i * 100 / allTagsCount)); //computing progress percentage



                }
            
            }
            catch (Exception ex)
            {
                OnNewEvent(new LogEventArgs("Error during database modification. " + ex));
            }
            finally
            {
                conn.Close(); //closing the connection
                stopwatch.Stop();
                if (tagsExisted > 0)
                {
                    OnNewEvent(new LogEventArgs("Added " + tagsAdded + " tags to the database, " + tagsExisted + " tags have already been in the database, time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString("F3") + " s"));
                }
                else
                {
                    OnNewEvent(new LogEventArgs("Added " + tagsAdded + " tags to the database, time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString("F3") + " s"));
                }
            }

        }

    }
}
