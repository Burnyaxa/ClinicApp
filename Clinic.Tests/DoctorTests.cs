using System.Collections.Generic;
using System.Linq;
using System.Net;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using Newtonsoft.Json;
using NUnit.Allure.Core;
using NUnit.Framework;
using PL.Controllers;
using PL.Models;
using RestSharp;

namespace Clinic.Tests
{
    public class DoctorTests
    {
        private const string path = "https://clinicpl.azurewebsites.net/api/";
        private DoctorCreateModel _initialDoctor;
        private DoctorUpdateModel _updateDoctor;
        private RestClient _client;
        
        [SetUp]
        public void Setup()
        {
            _client = new RestClient(path + "doctors");
            
           _initialDoctor = new DoctorCreateModel()
           {
               Address = "Kyiv",
               Cabinet = 1,
               FirstName = "Ivan",
               LastName = "Ivanov",
               Patronymic = "Ivanovich",
               PhoneNumber = "1111111111",
               Specialty = "Doctor"
           };
           
           _updateDoctor =  new DoctorUpdateModel()
           {
               Address = _initialDoctor.Address,
               Cabinet = _initialDoctor.Cabinet,
               FirstName = "John",
               LastName = "John",
               Patronymic = "John",
               PhoneNumber = _initialDoctor.PhoneNumber,
               Specialty = _initialDoctor.Specialty
           };
        }

        [Test]
        public void Post_CreatesDoctor_ReturnsCreatedCode()
        {
            //arrange
            var request = new RestRequest("", Method.POST);
            
            request.AddJsonBody(_initialDoctor);
            
            //act
            var response = _client.Execute(request);
            
            //assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
        
        [Test]
        public void Get_Doctor_ReturnsNewlyCreatedDoctor()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var getRequest = new RestRequest("", Method.GET);
            postRequest.AddJsonBody(_initialDoctor);
            
            //act
            _client.Execute(postRequest);
            var response = _client.Execute(getRequest);
            IEnumerable<DoctorDTO> doctors = JsonConvert.DeserializeObject<IEnumerable<DoctorDTO>>(response.Content);
            
            //assert
            Assert.That(doctors.Where(x => x.Address == _initialDoctor.Address && 
                                           x.Cabinet == _initialDoctor.Cabinet &&
                                           x.FirstName == _initialDoctor.FirstName &&
                                           x.LastName == _initialDoctor.LastName &&
                                           x.PhoneNumber == _initialDoctor.PhoneNumber).ToList().Count != 0);
        }
        
        [Test]
        public void Put_Doctor_UpdatesNewlyCreatedDoctorName()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var putRequest = new RestRequest("", Method.PUT);
            var getByIdRequest = new RestRequest("", Method.GET);
            
            postRequest.AddJsonBody(_initialDoctor);
            _client.Execute(postRequest);
            var postResponse = _client.Execute(postRequest);
            var createdDoc = JsonConvert.DeserializeObject<DoctorDTO>(postResponse.Content);
            
            _client = new RestClient(path + $"doctors/{createdDoc.Id}");
            putRequest.AddJsonBody(_updateDoctor);
            
            //act
            _client.Execute(putRequest);
            var getResponse = _client.Execute(getByIdRequest);
            var resultDoctor = JsonConvert.DeserializeObject<DoctorDTO>(getResponse.Content);
           
            //assert
            Assert.That(resultDoctor.FirstName == _updateDoctor.FirstName &&
                        resultDoctor.LastName == _updateDoctor.LastName &&
                        resultDoctor.Patronymic == _updateDoctor.Patronymic );
        }
        
        [Test]
        public void Delete_Doctor_DeletesNewlyCreatedDoctor()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var deleteRequest = new RestRequest("", Method.DELETE);
            var getByIdRequest = new RestRequest("", Method.GET);
            
            postRequest.AddJsonBody(_initialDoctor);
            _client.Execute(postRequest);
            var postResponse = _client.Execute(postRequest);
            var createdDoc = JsonConvert.DeserializeObject<DoctorDTO>(postResponse.Content);
            
            _client = new RestClient(path + $"doctors/{createdDoc.Id}");
            
            //act
            _client.Execute(deleteRequest);
            var getResponse = _client.Execute(getByIdRequest);
           
            //assert
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Post_CreatesDoctor_ReturnsCreatedCode1()
        {
            //arrange
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(_initialDoctor);

            //act
            var response = _client.Execute(request);

            //assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void Get_Doctor_ReturnsNewlyCreatedDoctor1()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var getRequest = new RestRequest("", Method.GET);
            postRequest.AddJsonBody(_initialDoctor);

            //act
            _client.Execute(postRequest);
            var response = _client.Execute(getRequest);
            IEnumerable<DoctorDTO> doctors = JsonConvert.DeserializeObject<IEnumerable<DoctorDTO>>(response.Content);

            //assert
            Assert.That(doctors.Where(x => x.Address == _initialDoctor.Address &&
                                           x.Cabinet == _initialDoctor.Cabinet &&
                                           x.FirstName == _initialDoctor.FirstName &&
                                           x.LastName == _initialDoctor.LastName &&
                                           x.PhoneNumber == _initialDoctor.PhoneNumber).ToList().Count != 0);
        }

        [Test]
        public void Put_Doctor_UpdatesNewlyCreatedDoctorName1()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var putRequest = new RestRequest("", Method.PUT);
            var getByIdRequest = new RestRequest("", Method.GET);

            postRequest.AddJsonBody(_initialDoctor);
            _client.Execute(postRequest);
            var postResponse = _client.Execute(postRequest);
            var createdDoc = JsonConvert.DeserializeObject<DoctorDTO>(postResponse.Content);

            _client = new RestClient(path + $"doctors/{createdDoc.Id}");
            putRequest.AddJsonBody(_updateDoctor);

            //act
            _client.Execute(putRequest);
            var getResponse = _client.Execute(getByIdRequest);
            var resultDoctor = JsonConvert.DeserializeObject<DoctorDTO>(getResponse.Content);

            //assert
            Assert.That(resultDoctor.FirstName == _updateDoctor.FirstName &&
                        resultDoctor.LastName == _updateDoctor.LastName &&
                        resultDoctor.Patronymic == _updateDoctor.Patronymic);
        }

        [Test]
        public void Delete_Doctor_DeletesNewlyCreatedDoctor1()
        {
            //arrange
            var postRequest = new RestRequest("", Method.POST);
            var deleteRequest = new RestRequest("", Method.DELETE);
            var getByIdRequest = new RestRequest("", Method.GET);

            postRequest.AddJsonBody(_initialDoctor);
            _client.Execute(postRequest);
            var postResponse = _client.Execute(postRequest);
            var createdDoc = JsonConvert.DeserializeObject<DoctorDTO>(postResponse.Content);

            _client = new RestClient(path + $"doctors/{createdDoc.Id}");

            //act
            _client.Execute(deleteRequest);
            var getResponse = _client.Execute(getByIdRequest);

            //assert
            Assert.AreEqual("John","Ivan");
        }

    }


}