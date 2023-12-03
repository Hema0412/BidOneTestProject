using BidOneDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using BidOneBusinessLayer.Interface;
namespace BidOneBusinessLayer
{

    /// <summary>
    /// Implementation of JSON file Generation with method addUser()
    /// </summary>
    public class UserService : IUserService
    {
        public bool addUser(UserEntity user)
        {

            var  output = false;
            try
            {

                if (!(string.IsNullOrEmpty(user.FirstName) && string.IsNullOrEmpty(user.LastName))) //Back-End Validation 
                {

                    user.FirstName = user.FirstName.Trim();
                    user.FirstName = Regex.Replace(user.FirstName, "[@&'(\\s)<>#]", "");
                    user.LastName = user.LastName.Trim();
                    user.LastName = Regex.Replace(user.LastName, "[@&'(\\s)<>#]", "");
                    string userjson = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
                    string path = Directory.GetCurrentDirectory();
                    string folderName = Path.Combine(path, "JSON File");
                    System.IO.Directory.CreateDirectory(folderName); //Folder Creation
                    string filePath = Path.Combine(folderName, "UserJSON.txt");
                    //System.IO.File.WriteAllText(fileName, userjson);

                    //code for Create file if not exist, else append data in same file
                    
                    if (!File.Exists(filePath))
                    {

                        File.Create(filePath).Dispose();

                        using (var writer = new StreamWriter(filePath))
                        {
                            writer.WriteLineAsync(userjson);
                            writer.FlushAsync();
                            output = true;
                        }
                    }



                    else if (File.Exists(filePath))
                    {
                        using (var file = File.Open(filePath, FileMode.Append, FileAccess.Write))
                        using (var writer = new StreamWriter(file))
                        {
                            writer.WriteLineAsync(userjson);
                            writer.FlushAsync();
                            output = true;
                        }
                    }
                    return output;
                }
                else
                {
                    return output;
                }
               
                        


                   
                
            }
            catch (Exception Ex)
            {


            }

            return output;

           
        }
    }
}
