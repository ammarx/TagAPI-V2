using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;
using System.IO;
using Ionic.Zip;

namespace TagAPIx
{

    public class Class1
    {

       static string versionnumber = null;
       

        internal static Dictionary<string, string[]> versionData = new Dictionary<string, string[]>
        {
        };

        internal static Dictionary<string, string[]> assetsList = new Dictionary<string, string[]>
        {
        };

        

    
        static string buildArguments = "";
        static string mcSave =  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/";
        public static void extractfile()
        {
            string mcLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/";
                
            try
            {
                foreach (string entry in versionData["natives"])
                {
                    otherDotNetZip.Extract(mcLocation + @"\libraries\" + entry, mcLocation + @"\versions\" + versionnumber + @"\" + versionnumber + "_TagCraftMC", "META-INF");
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            //return status;
        }
        

        public static void optionreader(String VersionNumber)
        {
            try
            {

                versionnumber = VersionNumber;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: '{0}'", ex);

            }
        }

        
        public static void main()
        {
            try
            {
                string mcLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/";

                string fileName = mcLocation + @"\versions\" + versionnumber + @"\" + versionnumber + ".json";


                if (File.Exists(fileName))
                {
                    versionData = otherJsonNet.getVersionData(fileName);
                }
                else
                {
                    //Error;
                }

                string mcNatives = "-Djava.library.path=\"" + mcLocation + @"\versions\" + versionnumber + @"\" + versionnumber + "_TagCraftMC\"";
                string mcLibraries = ""; 
                foreach (string entry in versionData["libraries"])
                {
                    mcLibraries = mcLibraries + "\"" + mcLocation + @"\libraries\" + entry + "\";";
                }
                string mcJar = "\"" + mcLocation + @"\versions\" + versionnumber + @"\" + versionnumber + ".jar\"";
                string mcClass = versionData["mainClass"][0];
                string mcArgs = versionData["minecraftArguments"][0];
     
      
                buildArguments = mcLibraries;

                string[] lines = { buildArguments };

                System.IO.File.WriteAllLines((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Arguments.txt"), lines);

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
           }
        }
    }
 
