﻿using System.Text.Json;
using System.Xml.Serialization;
using Lesson10.Entities;

var persons = new List<Person>
{
    new(1, "John"),
    new(2, "Person2"),
    new(3, "Person3"),
};
var department = new Department(1, "DepName", persons);

var outputArray = persons
    .Select(person => $"{person.Id},{person.Name}").ToArray();
File.WriteAllLines("Users.txt", outputArray);

var inputArray = File.ReadAllLines("Users.txt");
persons = inputArray
    .Select(str =>
        new Person(int.Parse(str.Split(",")[0]), str.Split(",")[1]))
    .ToList();

//xml
var format = new XmlSerializer(typeof(Department));
using (var fileStream = new FileStream("Users.xml", FileMode.OpenOrCreate))
{
    format.Serialize(fileStream, department);
}

Department newdepartment;
using (var fileStream = new FileStream("Users.xml", FileMode.OpenOrCreate))
{
    newdepartment = format.Deserialize(fileStream) as Department;
}

//json
using (var fileStream = new FileStream("Users.json", FileMode.OpenOrCreate))
{
    JsonSerializer.Serialize(fileStream, department);
}

Department newdepartment1;
using (var fileStream = new FileStream("Users.json", FileMode.OpenOrCreate))
{
    newdepartment1 = JsonSerializer.Deserialize<Department>(fileStream);
}

var person1 = new Person(1, "John")
{
    Id = 1
};
person1.SetPhone("0501234567");
// person1.Name = "John";

var person3 = new Person
{
    Id = 1,
    Name = "John"
};

var person2 = new Person();