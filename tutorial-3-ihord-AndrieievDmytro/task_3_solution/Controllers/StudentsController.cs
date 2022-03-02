using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;
using System.Linq;


namespace task_3_solution.Controller{
    [Route ("api/students")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try{
                var data = new CSVUtils("./data/students.csv");
                List<Student> students = data.Read();
                return Ok(JsonSerializer.Serialize(students));
            }
            catch(FileNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{indexNumber}")]
        public IActionResult Get(string indexNumber){
            try
            {
                var data = new CSVUtils("./data/students.csv");
                List<Student> students = data.Read();
                var student = students.First(s => s.IndexNumber.Equals(indexNumber));
                return Ok(JsonSerializer.Serialize(student));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{indexNumber}")]
        public IActionResult Put(string indexNumber , Student newStudent)
        {
            var data = new CSVUtils("./data/students.csv");
            Dictionary<string, Student> studentMap;
            List<Student> students;
            try
            {
                students = data.Read();
                studentMap = students.ToDictionary(s => s.IndexNumber);

            }
            catch (Exception)
            {
                studentMap = new Dictionary<string, Student>();
            }

            if(Utils.checkIndex(newStudent) == false)
            {   
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            if (Utils.checkNull(newStudent) == true)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            if(studentMap.Remove(indexNumber) == false)
            {
                return NotFound();
            }                
            newStudent.IndexNumber = indexNumber;
            studentMap.Add(indexNumber, newStudent);
            students = studentMap.Values.ToList();

            data.Write(students);
            return Ok(studentMap[indexNumber]);
        }

        [HttpPost]
        public IActionResult Post(Student newStudent)
        {
            var data = new CSVUtils("./data/students.csv");
            List<Student> students;
            try
            {
                students = data.Read();
            }
            catch (ArgumentNullException)
            {
                students = new List<Student>();
            }

            if(Utils.checkNull(newStudent) == true)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            data.InsertData(students,newStudent);
            return Ok(JsonSerializer.Serialize(newStudent));
                
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult Delete(string indexNumber)
        {
            try
            {
                var data = new CSVUtils("./data/students.csv");
                List<Student> students = data.Read();
                var studentMap = students.ToDictionary(s => s.IndexNumber);
                if(studentMap.Remove(indexNumber) == false)
                {
                    return NotFound();
                } 
                studentMap.Remove(indexNumber);
                students = studentMap.Values.ToList();
                data.Write(students);
                return Ok();
            }
            catch (FileNotFoundException) 
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
