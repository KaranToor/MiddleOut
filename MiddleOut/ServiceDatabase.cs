﻿//Author: Braxton Rowe
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Web.Script.Serialization;

namespace MiddleOut
{
    /// <summary>
    /// The Service Database class is where all Service objects are stored into their respective Dictionaries, sorted by  EnumTypes.
    /// </summary>
    class ServiceDatabase
    {
        #region fields
        private Dictionary<String, Service> myToys;
        private Dictionary<String, Service> myClothes;
        private Dictionary<String, Service> myTech;
        private Dictionary<String, Service> myFirstAid;
        private Dictionary<String, Service> myHygene;
        private Dictionary<String, Service> myTools;
        private Dictionary<String, Service> myFood;
        private Dictionary<String, Service> myOthers;
        private Dictionary<String, Service> myGoodsDrivers;
        private Dictionary<String, Service> myMathEducators;
        private Dictionary<String, Service> myReadingEducators;
        private Dictionary<String, Service> myWritingEducators;
        private Dictionary<String, Service> myDonationRequests;
        private Dictionary<String, String> mySerialNumbers;
        private List<String> myServiceIDs;
        private String myPath;
        private String myResourcePath;
        private String myFileName;
        // myStrings are the strings used to label the serial numbers in the serial.txt file.
        private String[] myStrings = new string[] {"toy_serial", "clothes_serial", "tech_serial", "first_aid_serial",
        "hygene_serial", "tools_serial", "food_serial", "other_serial", "goods_serial", "math_serial",
        "reading_serial", "writing_serial", "donation_serial", "driver_serial", "educator_serial"};
        // myDictionaryFileStrings are the strings that are used to create, read, write the files for their respective Service Dictionary.
        private String[] myDictionaryFileStrings = new string[] {
                    "Toy_Dictionary.txt", "Clothes_Dictionary.txt", "Tech_Dictionary.txt", "FirstAid_Dictionary.txt", "Hygene_Dictionary.txt",
                    "Tools_Dictionary.txt", "Food_Dictionary.txt", "Other_Dictionary.txt", "Goods_Dictionary.txt",
                    "Math_Dictionary.txt", "Reading_Dictionary.txt", "Writing_Dictionary.txt", "Donation_Dictionary.txt"};
        #endregion

        #region constructor
        /// <summary>
        /// Constructor for the Service Database.
        /// </summary>
        public ServiceDatabase()
        {
            createFilePath();
            initializeDictionaries();
            readSerialNumbers();
            myServiceIDs = new List<string>();
        }
        #endregion

        #region dominant method
        /// <summary>
        /// Creates a Service ID, updates the serial number file, adds the new Service object to it's respective dictionary, and updates the Service Dictionary's file.
        /// </summary>
        /// <param name="sType">The Service Type Enum.</param>
        /// <param name="dType">The Donation Type Enum.</param>
        /// <param name="theUser">The User object.</param>
        /// <param name="theService">The Service object.</param>
        public void createService(ServiceTypes sType, DonationTypes dType, User theUser, Service theService)
        {
            String serial;
            switch (sType)
            {
                case ServiceTypes.Donor:
                    switch (dType)
                    {
                        case DonationTypes.Toys:
                            theService.setServiceID(createServiceID(dType));
                            myToys.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myToys);
                            writeFile(myDictionaryFileStrings[0], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Clothes:
                            theService.setServiceID(createServiceID(dType));
                            myClothes.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myClothes);
                            writeFile(myDictionaryFileStrings[1], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Tech:
                            theService.setServiceID(createServiceID(dType));
                            myTech.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myTech);
                            writeFile(myDictionaryFileStrings[2], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.FirstAid:
                            theService.setServiceID(createServiceID(dType));
                            myFirstAid.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myFirstAid);
                            writeFile(myDictionaryFileStrings[3], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Food:
                            theService.setServiceID(createServiceID(dType));
                            myFood.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myFood);
                            writeFile(myDictionaryFileStrings[4], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Hygene:
                            theService.setServiceID(createServiceID(dType));
                            myHygene.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myHygene);
                            writeFile(myDictionaryFileStrings[5], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Tools:
                            theService.setServiceID(createServiceID(dType));
                            myTools.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myTools);
                            writeFile(myDictionaryFileStrings[6], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.Other:
                            theService.setServiceID(createServiceID(dType));
                            myOthers.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myOthers);
                            writeFile(myDictionaryFileStrings[7], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                    }
                    break;
                case ServiceTypes.Driver:
                    switch (dType)
                    {
                        case DonationTypes.TransportGoods:
                            theService.setServiceID(createServiceID(dType));
                            myGoodsDrivers.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myGoodsDrivers);
                            writeFile(myDictionaryFileStrings[8], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                    }
                    break;
                case ServiceTypes.Educator:
                    switch (dType)
                    {
                        case DonationTypes.MathEducator:
                            theService.setServiceID(createServiceID(dType));
                            myMathEducators.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myMathEducators);
                            writeFile(myDictionaryFileStrings[9], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.WritingEducator:
                            theService.setServiceID(createServiceID(dType));
                            myWritingEducators.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myWritingEducators);
                            writeFile(myDictionaryFileStrings[11], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                        case DonationTypes.ReadingEducator:
                            theService.setServiceID(createServiceID(dType));
                            myReadingEducators.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myReadingEducators);
                            writeFile(myDictionaryFileStrings[10], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                    }
                    break;
                case ServiceTypes.Requester:
                    switch (dType)
                    {
                        case DonationTypes.DonationRequest:
                            theService.setServiceID(createServiceID(dType));
                            myDonationRequests.Add(theService.getServiceID(), theService);
                            serial = serializeDictionary(myDonationRequests);
                            writeFile(myDictionaryFileStrings[12], serial);
                            myServiceIDs.Add(theService.getServiceID());
                            break;
                    }
                    break;
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Helper method for the createService method that creates the Service ID for the Service object.
        /// </summary>
        /// <param name="theType">The Donation EnumType of the Service object.</param>
        /// <returns></returns>
        private String createServiceID(DonationTypes theType)
        {
            StringBuilder builder = new StringBuilder();
            switch (theType)
            {
                case DonationTypes.Toys:
                    builder.Append("11");
                    builder.Append(mySerialNumbers[myStrings[0]]);
                    updateSerial(myStrings[0]);
                    break;
                case DonationTypes.Clothes:
                    builder.Append("12");
                    builder.Append(mySerialNumbers[myStrings[1]]);
                    updateSerial(myStrings[1]);
                    break;
                case DonationTypes.Tech:
                    builder.Append("13");
                    builder.Append(mySerialNumbers[myStrings[2]]);
                    updateSerial(myStrings[2]);
                    break;
                case DonationTypes.FirstAid:
                    builder.Append("14");
                    builder.Append(mySerialNumbers[myStrings[3]]);
                    updateSerial(myStrings[3]);
                    break;
                case DonationTypes.Hygene:
                    builder.Append("15");
                    builder.Append(mySerialNumbers[myStrings[4]]);
                    updateSerial(myStrings[4]);
                    break;
                case DonationTypes.Food:
                    builder.Append("16");
                    builder.Append(mySerialNumbers[myStrings[5]]);
                    updateSerial(myStrings[5]);
                    break;
                case DonationTypes.Tools:
                    builder.Append("17");
                    builder.Append(mySerialNumbers[myStrings[6]]);
                    updateSerial(myStrings[6]);
                    break;
                case DonationTypes.Other:
                    builder.Append("18");
                    builder.Append(mySerialNumbers[myStrings[7]]);
                    updateSerial(myStrings[7]);
                    break;
                case DonationTypes.TransportGoods:
                    builder.Append("21");
                    builder.Append(mySerialNumbers[myStrings[9]]);
                    updateSerial(myStrings[9]);
                    break;
                case DonationTypes.MathEducator:
                    builder.Append("31");
                    builder.Append(mySerialNumbers[myStrings[10]]);
                    updateSerial(myStrings[10]);
                    break;
                case DonationTypes.ReadingEducator:
                    builder.Append("32");
                    builder.Append(mySerialNumbers[myStrings[11]]);
                    updateSerial(myStrings[11]);
                    break;
                case DonationTypes.WritingEducator:
                    builder.Append("33");
                    builder.Append(mySerialNumbers[myStrings[12]]);
                    updateSerial(myStrings[12]);
                    break;
                case DonationTypes.DonationRequest:
                    builder.Append("41");
                    builder.Append(mySerialNumbers[myStrings[13]]);
                    updateSerial(myStrings[13]);
                    break;
            }
            return builder.ToString();
        }

        /// <summary>
        /// Helper method for the createServiceID method to update the seral number file with the next serial numbers.
        /// </summary>
        /// <param name="theType">The type of Service object used as a key for the mySerialNumbers dictionary.</param>
        private void updateSerial(String theType)
        {
            int serial = Convert.ToInt32(mySerialNumbers[theType]);
            serial -= 10000;
            serial += 1;
            serial += 10000;

            mySerialNumbers[theType] = Convert.ToString(serial);
            File.WriteAllText(myFileName, new JavaScriptSerializer().Serialize(mySerialNumbers));
        }

        /// <summary>
        /// Helper method for the createService method to serialize the Service Dictionary to write to its respective file.
        /// </summary>
        /// <param name="theDictionary">The dicionary to be serialized.</param>
        /// <returns></returns>
        private string serializeDictionary(Dictionary<String, Service> theDictionary)
        {

            string serial = JsonConvert.SerializeObject(theDictionary, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            return serial;
        }

        /// <summary>
        /// Helper method for the createService method to write the serialized string to its respective file.
        /// </summary>
        /// <param name="fileName">The file name to be written/overwritten.</param>
        /// <param name="serialization">The serialized string representing the dictionary being written.</param>
        private void writeFile(String fileName, String serialization)
        {
            File.WriteAllText(fileName, serialization);
        }

        /// <summary>
        /// Helper method for the constructor to build the file paths for new files.
        /// </summary>
        private void createFilePath()
        {
            myPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            myResourcePath = Path.Combine(myPath, "Resources");
            myFileName = Path.Combine(myPath, "serial_list.txt");
        }

        /// <summary>
        /// Helper method for the constructor to initialize the Dictionaries when a new database is created.
        /// This method calls the pullDictionary method if the program has been run on the machine before.
        /// </summary>
        private void initializeDictionaries()
        {
            myToys = new Dictionary<String, Service>();
            myClothes = new Dictionary<String, Service>();
            myTech = new Dictionary<String, Service>();
            myFirstAid = new Dictionary<String, Service>();
            myHygene = new Dictionary<String, Service>();
            myTools = new Dictionary<String, Service>();
            myFood = new Dictionary<String, Service>();
            myOthers = new Dictionary<String, Service>();
            myGoodsDrivers = new Dictionary<String, Service>();
            myMathEducators = new Dictionary<String, Service>();
            myReadingEducators = new Dictionary<String, Service>();
            myWritingEducators = new Dictionary<String, Service>();
            myDonationRequests = new Dictionary<String, Service>();
            mySerialNumbers = new Dictionary<string, string>();

            if (!File.Exists(myFileName))
            {

                for (int i = 0; i < myStrings.Length; i++)
                {
                    mySerialNumbers.Add(myStrings[i], "10000");
                }

                createSerialFile();
            }
            else
            {
                pullDictionary(myDictionaryFileStrings[0], 1);
                pullDictionary(myDictionaryFileStrings[1], 2);
                pullDictionary(myDictionaryFileStrings[2], 3);
                pullDictionary(myDictionaryFileStrings[3], 4);
                pullDictionary(myDictionaryFileStrings[4], 5);
                pullDictionary(myDictionaryFileStrings[5], 6);
                pullDictionary(myDictionaryFileStrings[6], 7);
                pullDictionary(myDictionaryFileStrings[7], 8);
                pullDictionary(myDictionaryFileStrings[8], 9);
                pullDictionary(myDictionaryFileStrings[9], 10);
                pullDictionary(myDictionaryFileStrings[10], 11);
                pullDictionary(myDictionaryFileStrings[11], 12);
                pullDictionary(myDictionaryFileStrings[12], 13);
            }
        }

        /// <summary>
        /// Helper method for the initializeDictionaries method that creats the serial number file.
        /// </summary>
        private void createSerialFile()
        {
            File.WriteAllText(myFileName, new JavaScriptSerializer().Serialize(mySerialNumbers));
        }

        /// <summary>
        /// Helper method for the initializeDirectories method to pull information from files of existing Service object created.
        /// </summary>
        /// <param name="filePath">The file name for the dictionary.</param>
        /// <param name="theDictionary">The dictionary being populated.</param>
        private void pullDictionary(String filePath, int theDictionary)
        {
            if (File.Exists(filePath))
            {
                String deSerial = File.ReadAllText(filePath);
                deSerializeDictionary(deSerial, theDictionary);
            }
        }

        /// <summary>
        /// Helper method for the pullDictionary method to deserialize the string from the file into its respective dictionary.
        /// </summary>
        /// <param name="theSerial">The string representing the dictionary.</param>
        /// <param name="theDictionary">The dictionary being updated.</param>
        private void deSerializeDictionary(String theSerial, int theDictionary)
        {
            object dictionary = JsonConvert.DeserializeObject(theSerial, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });
            switch (theDictionary)
            {
                case 1:
                    myToys = (Dictionary<String, Service>)dictionary;
                    break;
                case 2:
                    myClothes = (Dictionary<String, Service>)dictionary;
                    break;
                case 3:
                    myTech = (Dictionary<String, Service>)dictionary;
                    break;
                case 4:
                    myFirstAid = (Dictionary<String, Service>)dictionary;
                    break;
                case 5:
                    myHygene = (Dictionary<String, Service>)dictionary;
                    break;
                case 6:
                    myTools = (Dictionary<String, Service>)dictionary;
                    break;
                case 7:
                    myFood = (Dictionary<String, Service>)dictionary;
                    break;
                case 8:
                    myOthers = (Dictionary<String, Service>)dictionary;
                    break;
                case 9:
                    myGoodsDrivers = (Dictionary<String, Service>)dictionary;
                    break;
                case 10:
                    myMathEducators = (Dictionary<String, Service>)dictionary;
                    break;
                case 11:
                    myReadingEducators = (Dictionary<String, Service>)dictionary;
                    break;
                case 12:
                    myWritingEducators = (Dictionary<String, Service>)dictionary;
                    break;
                case 13:
                    myDonationRequests = (Dictionary<String, Service>)dictionary;
                    break;
            }

        }

        /// <summary>
        /// Helper method for the constructor to populate the serial numbers for the Service objects.
        /// </summary>
        private void readSerialNumbers()
        {
            mySerialNumbers = new JavaScriptSerializer()
                    .Deserialize<Dictionary<string, string>>(File.ReadAllText(myFileName));
        }
        #endregion

        #region public methods
        /// <summary>
        /// Checks to see if the Service ID exists.
        /// </summary>
        /// <param name="serviceID">The Service ID.</param>
        /// <returns>Returns true if it exists, false if it does not.</returns>
        public Boolean isService(String serviceID)
        {
            return myServiceIDs.Contains(serviceID);
        }

        /// <summary>
        /// Sends a Service object correlated with the Service ID.
        /// </summary>
        /// <param name="serviceID">The Service ID.</param>
        /// <returns>Returns the Service object.</returns>
        public Service retrieveService(String serviceID)
        {
            Service service = new Service(null, null);
            string sType = serviceID.Substring(0, 1);
            string dType = serviceID.Substring(1, 1);
            switch (sType)
            {
                case "1":
                    switch (dType)
                    {
                        case "1":
                            service = myToys[serviceID];
                            break;
                        case "2":
                            service = myClothes[serviceID];
                            break;
                        case "3":
                            service = myTech[serviceID];
                            break;
                        case "4":
                            service = myFirstAid[serviceID];
                            break;
                        case "5":
                            service = myHygene[serviceID];
                            break;
                        case "6":
                            service = myFood[serviceID];
                            break;
                        case "7":
                            service = myTools[serviceID];
                            break;
                        case "8":
                            service = myOthers[serviceID];
                            break;
                    }
                    break;
                case "2":
                    service = myGoodsDrivers[serviceID];
                    break;
                case "3":
                    switch (dType)
                    {
                        case "1":
                            service = myMathEducators[serviceID];
                            break;
                        case "2":
                            service = myReadingEducators[serviceID];
                            break;
                        case "3":
                            service = myWritingEducators[serviceID];
                            break;
                    }
                    break;
                case "4":
                    switch (dType)
                    {
                        case "1":
                            service = myDonationRequests[serviceID];
                            break;
                    }
                    break;
            }
            return service;
        }

        /// <summary>
        /// Provides a string of all of the Service object IDs in their respective dictionaries.
        /// </summary>
        /// <param name="sType">The service type requested.</param>
        /// <returns></returns>
        public String printServices(ServiceTypes sType)
        {
            String print = "";
            switch (sType)
            {
                case ServiceTypes.Donor:
                    print = getServices(myToys);
                    print = getServices(myClothes);
                    print = getServices(myTech);
                    print = getServices(myFirstAid);
                    print = getServices(myFood);
                    print = getServices(myHygene);
                    print = getServices(myTools);
                    print = getServices(myOthers);
                    break;
                case ServiceTypes.Educator:
                    print = getServices(myMathEducators);
                    print = getServices(myReadingEducators);
                    print = getServices(myWritingEducators);
                    break;
                case ServiceTypes.Requester:
                    print = getServices(myDonationRequests);
                    break;
            }
            return print;
        }

        /// <summary>
        /// Provides all of the Service object IDs in their respective dictionaries.
        /// </summary>
        /// <param name="sType">The Service type requested.</param>
        /// <param name="dType">The Donation type requested.</param>
        /// <returns></returns>
        public String printServices(ServiceTypes sType, DonationTypes dType)
        {
            String print = "";
            switch (sType)
            {
                case ServiceTypes.Donor:
                    switch (dType)
                    {
                        case DonationTypes.Toys:
                            print = getServices(myToys);
                            break;
                        case DonationTypes.Clothes:
                            print = getServices(myClothes);
                            break;
                        case DonationTypes.Tech:
                            print = getServices(myTech);
                            break;
                        case DonationTypes.FirstAid:
                            print = getServices(myFirstAid);
                            break;
                        case DonationTypes.Food:
                            print = getServices(myFood);
                            break;
                        case DonationTypes.Hygene:
                            print = getServices(myHygene);
                            break;
                        case DonationTypes.Tools:
                            print = getServices(myTools);
                            break;
                        case DonationTypes.Other:
                            print = getServices(myOthers);
                            break;
                    }
                    break;
                case ServiceTypes.Driver:
                    switch (dType)
                    {
                        case DonationTypes.TransportGoods:
                            print = getServices(myGoodsDrivers);
                            break;
                    }
                    break;
                case ServiceTypes.Educator:
                    switch (dType)
                    {
                        case DonationTypes.MathEducator:
                            print = getServices(myMathEducators);
                            break;
                        case DonationTypes.WritingEducator:
                            print = getServices(myWritingEducators);
                            break;
                        case DonationTypes.ReadingEducator:
                            print = getServices(myReadingEducators);
                            break;
                    }
                    break;
                case ServiceTypes.Requester:
                    print = getServices(myDonationRequests);
                    break;
            }
            return print;
        }

        /// <summary>
        /// Helper method for the printServices methods that prints out each Service ID of each Service object from the dictionary requested.
        /// </summary>
        /// <param name="theDictionary">The dictionary requested.</param>
        /// <returns></returns>
        private String getServices(Dictionary<String, Service> theDictionary)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<String, Service> entry in myTech)
            {
                builder.Append(entry.Value.getServiceID() + "\n");
            }
            return builder.ToString();
        }
        #endregion
    }

}