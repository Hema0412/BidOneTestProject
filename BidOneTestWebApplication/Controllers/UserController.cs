/**
 * Author:    Hemalatha Lakshmanan
 * Created:   03.12.2023
 * 
 * Description : -- A simple ASP .Net Core(V8.0) MVC Application to Add users and store the result as JSON file.
                 -- It has 3-tier architecture with Business, Data and WebUI layers.
                 -- Data handling and JSON creation has been implemented in Business Layer using Interfaces.
                 -- JSON File will be created in the WEBUI project with the folder name "JSON File". 
                 -- Folder and File will be created if not exist, if File exists, data will be appended in the single JSON File
                    with CreatedON Date field as additional parameter.
                 -- Data validation has been handled both in Front end and Back end.
 **/


using BidOneTestWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using AutoMapper;
using BidOneBusinessLayer;
using BidOneDataAccessLayer.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using BidOneBusinessLayer.Interface;


namespace BidOneTestWebApplication.Controllers
{


    /// <summary>
    /// Main controller for the Application
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Interface in Business class
        /// </summary>
      IUserService _userService=new UserService();

       
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel UserView)
        {
            try
            {
               

               if (ModelState.IsValid)
                {
                    //Auto Mapper has been used to Map the Model Objects to Entity Objects.
                    var usermapper = new MapperConfiguration(
                        cfg =>
                            {
                                cfg.CreateMap<UserViewModel, UserEntity>();
                            }).CreateMapper();
                    UserEntity user = usermapper.Map<UserEntity>(UserView);

                    //Implementation for JSON file creation is handles in Business Layer
                    bool result = _userService.addUser(user);

                    if(result==true)

                        {

                        return RedirectToAction("AddUser");
                        }
                    else
                        {

                        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

                        }
                    

                }

            }
            catch(Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

   
}
