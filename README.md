# Database Creator For Asix
Application that helps developing automation systems with B&R X20 PLCs and Asix Evo 9.

To make use of the application, following requirements should be met at first:  
- B&R X20 series PLC with configured OPC UA server should be available on the network (also works with simulator)  
- Program should be present in the PLC (it is necessary to enable tags in OpcUaMap) and PLC has to be in RUN mode  
- Asix Evo 9 application with .mdb database should be created (database can either have tags already added or not)  

![Alt text](screens/screen001.png?raw=true "Application start")

Application window consists of following elements:  
- Buttons for reading OPC tags and writing to the database  
- OPC address input field  
- Radio buttons for choosing whether existing tags should be overwritten  
- Progress bar  
- List view for tags preview with checkbox for demanding preview  
- Log list view  
- Status strip  

Window can be enlarged – then the height of tags list view increases.

![Alt text](screens/screen002.png?raw=true "Getting tags")

After entering correct OPC server address and clicking “Get OPC tags” button, OPC connection is opened and enabled tags’ names and units are copied to internal memory. Furthermore, all necessary tag parameters for the database are evaluated. Tags’ names in the database will be prefixed with “::”. Structure tags’ names are made by connecting ancestors’ names. Enabling “Preview tag list” refreshes the tag list. It can be done live, during reading process, however it may cause increasing operation time. 

![Alt text](screens/screen003.png?raw=true "Preview tags")

Most important evaluated parameters can be seen in the preview. In this step, user can check data validity.  Also “Add new tags” or “Overwrite database” mode should be chosen. The first option adds tags that are not present in the database and ignores ones that were present before. The second options deletes all the tags from the database and adds all the tags from the PLC. 

![Alt text](screens/screen004.png?raw=true "Modifying database")

After clicking “Add tags to database” button, user is asked to show existing Asix database path. Application is creating backup and checking if the file is correct. Then, the database is modified according to selected mode.

![Alt text](screens/screen005.png?raw=true "Preview added tags")

When the operation is done, tags that were added are marked yellow.