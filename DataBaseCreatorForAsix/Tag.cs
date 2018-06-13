using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workstation.ServiceModel.Ua;
using Workstation.ServiceModel.Ua.Channels;

namespace DataBaseCreatorForAsix
{
    /// <summary>
    /// Represents a single tag.
    /// </summary>
    public class Tag: IEquatable<Tag>
    {                                                                           //Column number in database
        public string Name { get; private set; } = "";                          //0
        public string Address { get; private set; } = "";                       //1
        public string ConversionFunction { get; set; } = "NIC_FP";              //2
        public string Archive { get; private set; } = "Archiwum";               //3
        public string ArchivingParameters { get; private set; } = "D,1s,,1s";   //4
        public string Format { get; set; } = "";                                //5
        public string Unit { get; set; } = "";                                  //6
        public string DisplayRangeFrom { get; private set; } = "0";             //7
        public string DisplayRangeTo { get; private set; } = "0";               //8
        public string MeasurementRangeFrom { get; private set; } = "0";         //9
        public string MeasurementRangeTo { get; private set; } = "0";           //10
        public string StateNames { get; set; } = "";                            //11
        public string Group2 { get; private set; }   =  "CPU";                  //12
        public string Group3 { get; set; } = "";                                //13
        public string Group4 { get; set; } = "";                                //14
        public string Group5 { get; set; } = "";                                //15
        public string ImportIgnored { get; set; } = "";                         //16
        public string Description { get; set; } = "";                           //17
        public string Channel { get; private set; } = "OPC1";                   //18
        public string ElementsCount { get; private set; } = "1";                //19
        public string SampleRate { get; private set; } = "1";                   //20
        public string Group1 { get; private set; } = "PLC";                     //21
        public string ItemNotActive { get; private set; } = "false";            //22
        public string CreationDate { get; set; } = "";                          //23
        public string DeletionDate { get; set; } = "";                          //24
        public string BarRangeFrom { get; private set; } = "0";                 //25
        public string BarRangeTo { get; private set; } = "0";                   //26

        public bool IsAdded { get; set; } = false;

        /// <summary>
        /// Constructor that takes ReferenceDescription list to make proper tag's name and address (that consists of all ancestors' names in the tree)
        /// </summary>
        public Tag(List<ReferenceDescription> rds)
        {
            for (int i=0;i<rds.Count;i++)
            {
                if (i==0)
                {
                    Name = rds[i].DisplayName.ToString();
                    Address = @"ns=urn:B&R/pv/;s=::AsGlobalPV:" + rds[i].DisplayName.ToString().Substring(2);
                }
                else
                {
                    Name += "_" + rds[i].DisplayName.ToString();
                    Address += "." + rds[i].DisplayName.ToString();
                }
            }
        }
        
        /// <summary>
        /// Constructor for tags with no ancestors - takes only name
        /// </summary>
        public Tag(string Name)
        {
            this.Name = Name;
            Address = @"ns=urn:B&R/pv/;s=::AsGlobalPV:" + Name.Substring(2);
        }

        /// <summary>
        /// Parameterless constructor - for creating empty tag to be later modified by NestedName method 
        /// </summary>
        public Tag()
        {

        }

        /// <summary>
        /// Adds descendant to tag
        /// </summary>
        public void NestedName(string NamePart)
        {
            Name += "_" + NamePart;
            Address += "." + NamePart;
        }

        //IEquatable<Tag> implementation
        public bool Equals(Tag otherTag)
        {
            return Name.Equals(otherTag.Name);
        }

        public override bool Equals(object otherObject)
        {
            if (!(otherObject is Tag))
            {
                return false;
            }
            return Equals((Tag)otherObject);
        }

        public override int GetHashCode() { return Name.GetHashCode(); }

        //operators overloading
        public static bool operator == (Tag tag1, Tag tag2)
        {
            if (tag1 == null || tag2 == null) return false;
            return tag1.Equals(tag2);
        }

        public static bool operator != (Tag tag1, Tag tag2)
        {
            if (tag1 == null || tag2 == null) return true;
            return !tag1.Equals(tag2);
        }
    }
}
