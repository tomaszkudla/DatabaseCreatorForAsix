using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workstation.ServiceModel.Ua;
using Workstation.ServiceModel.Ua.Channels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;



namespace DataBaseCreatorForAsix
{
    /// <summary>
    /// Represents OPC server on the PLC.
    /// </summary>
    class OPCserver
    {

        /// <summary>
        /// Event raised after a tag is get.
        /// </summary>
        public event EventHandler<NewTagAddedArgs> NewTagAdded;

        /// <summary>
        /// Event raised when the progress in getting tags is made (to simplify, it takes into consideration only first level tags).
        /// </summary>
        public event EventHandler<ProgressChangedArgs> ProgressChanged;

        /// <summary>
        /// Event raised when there is new info to be logged.
        /// </summary>
        public event EventHandler<LogEventArgs> NewEvent;

        /// <summary>
        /// List of tags - methods work result.
        /// </summary>
        public List<Tag> Tags { get; private set; }

        /// <summary>
        /// Raising NewTagAdded event. 
        /// </summary>
        public void OnNewTagAdded(NewTagAddedArgs newTagAddedArgs)
        {
            NewTagAdded?.Invoke(this, newTagAddedArgs);
        }

        /// <summary>
        /// Raising ProgressChanged event. 
        /// </summary>
        public void OnProgressChanged(ProgressChangedArgs progressChangedArgs)
        {
            ProgressChanged?.Invoke(this, progressChangedArgs);
        }

        /// <summary>
        /// Raising NewEvent event. 
        /// </summary>
        public void OnNewEvent(LogEventArgs logEventArgs)
        {
            NewEvent?.Invoke(this, logEventArgs);
        }

        /// <summary>
        /// Most important method - reading the tags. 
        /// </summary>
        public async Task<List<Tag>> OPCReadAsync(string OPCAdress)
        {
            //Preparing data to connect to OPC server
            Tags  = new List<Tag>();
            var loggerFactory = new LoggerFactory();

            var appDescription = new ApplicationDescription()
            {
                ApplicationName = "OPC",
                ApplicationUri = $"urn:{System.Net.Dns.GetHostName()}:OPC",
                ApplicationType = ApplicationType.Client,
            };

            var certificateStore = new DirectoryStore(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Workstation.ConsoleApp", "pki"));

            var channel = new UaTcpSessionChannel(
                appDescription,
                certificateStore,
                new AnonymousIdentity(), //by now doesn't support signing in
                OPCAdress,
                loggerFactory: loggerFactory);

            try
            {
                Stopwatch stopwatch = new Stopwatch(); //measuring operations time
                stopwatch.Start();

                await channel.OpenAsync(); //opening channel
                OnNewEvent(new LogEventArgs("Connected to OPC Server"));
                
                //opening OPC tree branches to find actual tags - only proper for B&R X20 PLC
                BrowseRequest browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = NodeId.Parse(ObjectIds.RootFolder), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                BrowseResponse browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[0].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[1].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[0].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[0].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[1].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                browseResponse = await channel.BrowseAsync(browseRequest);
                browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(browseResponse.Results[0].References[10].NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                BrowseResponse browseResponse0 = await channel.BrowseAsync(browseRequest);
                int nestingLevel = 0; //nesting level counter
                Tag tag = new Tag(); //initializing first tag
                int allTagsCount = browseResponse0.Results[0].References.Length - 1; //for counting progress percentage

                for (int i = browseResponse0.Results[0].References.Length - 1; i >= 0; i--) //first level loop
                {
                    var rd = browseResponse0.Results[0].References[i];
                    if (Tags.Count > 0 && rd.DisplayName.ToString() == Tags[0].Name) { break; } //to avoid getting the same tags second time

                    nestingLevel = 0;
                    ReadValueId[] items = new ReadValueId[1];
                    items[0] = new ReadValueId { NodeId = NodeId.Parse(rd.NodeId.ToString()), AttributeId = AttributeIds.DataType };
                    ReadRequest readRequest = new ReadRequest { NodesToRead = items };
                    ReadResponse readResponse = await channel.ReadAsync(readRequest);

                  
                    if (string.IsNullOrEmpty(tag.Name)) tag = new Tag(rd.DisplayName.ToString());
                    

                    if (readResponse.Results[0].Value != null)
                        tag.ConversionFunction = Typ(readResponse.Results[0].Value.ToString());
   
                    browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(rd.NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                    browseResponse = await channel.BrowseAsync(browseRequest);
                    foreach (var rd1 in browseResponse.Results[0].References ?? new ReferenceDescription[0]) //second level loop (nesting=1)
                    {
                        if (!rd1.NodeId.ToString().Contains("#"))
                        {
                            nestingLevel = 1;
                            tag = await ReadTag(new ReferenceDescription[] { rd, rd1 }, channel, tag);
                            browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(rd1.NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                            browseResponse = await channel.BrowseAsync(browseRequest);
                            foreach (var rd2 in browseResponse.Results[0].References ?? new ReferenceDescription[0]) //third level loop (nesting=2)
                            {

                                if (!rd2.NodeId.ToString().Contains("#"))
                                {
                                    nestingLevel = 2;
                                    tag = await ReadTag(new ReferenceDescription[] { rd, rd1, rd2 }, channel, tag);
                                    browseRequest = new BrowseRequest { NodesToBrowse = new BrowseDescription[] { new BrowseDescription { NodeId = ExpandedNodeId.ToNodeId(rd2.NodeId, channel.NamespaceUris), BrowseDirection = BrowseDirection.Forward, ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences), NodeClassMask = (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, IncludeSubtypes = true, ResultMask = (uint)BrowseResultMask.All } }, };
                                    browseResponse = await channel.BrowseAsync(browseRequest);
                                    foreach (var rd3 in browseResponse.Results[0].References ?? new ReferenceDescription[0]) //fourth level loop (nesting=3)
                                    {
                                        if (!rd3.NodeId.ToString().Contains("#"))
                                        {
                                            nestingLevel = 3;
                                            tag = await ReadTag(new ReferenceDescription[] { rd, rd1, rd2, rd3 }, channel, tag);
                                        }
                                        else if (rd3.NodeId.ToString().Contains("#EngineeringUnits"))
                                            await ReadUnit(new ReferenceDescription[] { rd, rd1, rd2, rd3 }, channel, tag);
                                        
                                        if (nestingLevel == 3 && !string.IsNullOrEmpty(tag.Name))           
                                            tag = SaveTag(tag);
                                        
                                    }
                                }
                                else if (rd2.NodeId.ToString().Contains("#EngineeringUnits"))
                                    await ReadUnit(new ReferenceDescription[] { rd, rd1, rd2 }, channel, tag);
                                

                                if (nestingLevel == 2 && !string.IsNullOrEmpty(tag.Name))
                                    tag = SaveTag(tag);     
                            }
                        }

                        else if (rd1.NodeId.ToString().Contains("#EngineeringUnits"))
                            await ReadUnit(new ReferenceDescription[] { rd, rd1 }, channel, tag);
                        

                        if (nestingLevel == 1 && !string.IsNullOrEmpty(tag.Name))
                            tag = SaveTag(tag);
                    }
                    if (nestingLevel == 0 && !string.IsNullOrEmpty(tag.Name))
                        tag = SaveTag(tag);

                    OnProgressChanged(new ProgressChangedArgs((allTagsCount-i)*100 / allTagsCount)); //computing progress percentage
                }


                await channel.CloseAsync(); //closing the channel
                stopwatch.Stop();

                OnNewEvent(new LogEventArgs(Tags.Count + " tags read, time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString("F3")+" s"));

            }
            catch (Exception ex)
            {
                OnNewEvent(new LogEventArgs("Error connecting to OPC server."));
                await channel.AbortAsync();
            }

            return Tags;
        }

        /// <summary>
        /// Converts OPC data type to Asix ConversionFunction.
        /// </summary>
        static string Typ(string nodeID)
        {
            switch (nodeID)
            {
                case "i=1":
                    return "NIC";//BOOL
                case "i=2":
                    return "NIC_BYTE";//Sbyte"
                case "i=3":
                    return "NIC_BYTE";//Byte
                case "i=4":
                    return "NIC_INT";//Int16
                case "i=5":
                    return "NIC_INT";//UInt16
                case "i=6":
                    return "NIC_LONG";//Int32
                case "i=7":
                    return "NIC_LONG";//UInt32
                case "i=8":
                    return "NIC_INT64";//Int64
                case "i=9":
                    return "NIC_INT64";//UInt64
                case "i=10":
                    return "NIC_FP";//Float
                case "i=11":
                    return "NIC_DOUBLE";//Double
                case "i=12":
                    return "NIC";//String
                case "i=13":
                    return "DATACZAS";//DataTime
                case "i=22":
                    return "NIC";//Struct
                default:
                    return "NIC_FP";
            }

        }

        /// <summary>
        /// Reads first/next level of tag tree. 
        /// </summary>
        async Task<Tag> ReadTag(ReferenceDescription[] rds, UaTcpSessionChannel channel, Tag tag)
        {
            ReadValueId[] items = new ReadValueId[1];
            items[0] = new ReadValueId { NodeId = NodeId.Parse(rds.Last().NodeId.ToString()), AttributeId = AttributeIds.DataType };
            ReadRequest readRequest = new ReadRequest { NodesToRead = items };
            ReadResponse readResponse = await channel.ReadAsync(readRequest);

            if (string.IsNullOrEmpty(tag.Name))
            {
                tag = new Tag(rds.Take(rds.Length-1).ToList());
            }
            tag.NestedName(rds.Last().DisplayName);

            if (rds.Length > 2)
                tag.Group4 = rds[1].DisplayName.ToString();
            if (rds.Length > 1)
                tag.Group3 = rds[0].DisplayName.ToString();

            if (readResponse.Results[0].Value != null)
            { tag.ConversionFunction = Typ(readResponse.Results[0].Value.ToString()); }

            return tag;
        }

        /// <summary>
        /// Reads tag unit.
        /// </summary>
        async Task ReadUnit(ReferenceDescription[] rds, UaTcpSessionChannel channel, Tag tag)
        {
            ReadValueId[] unit = new ReadValueId[1];
            unit[0] = new ReadValueId { NodeId = NodeId.Parse(rds.Last().NodeId.ToString()), AttributeId = AttributeIds.Value };
            ReadRequest unitRequest = new ReadRequest { NodesToRead = unit };
            ReadResponse unitResponse = await channel.ReadAsync(unitRequest);

            ExtensionObject EO = (ExtensionObject)unitResponse.Results[0].Value;
            EUInformation EU = (EUInformation)EO.Body;

            tag.Unit = EU.DisplayName; //zapis jednostki   
        }

        /// <summary>
        /// Adds tag to the list.
        /// </summary>
        Tag SaveTag(Tag tag)
        {
            NewTagAddedArgs newTagAddedArgs = new NewTagAddedArgs(tag);
            OnNewTagAdded(newTagAddedArgs);
            Tags.Add(tag);
            return new Tag();
        }
    }
}
