﻿namespace Lesson34.DAO;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Data { get; set; }
    public List<User> Users { get; set; }
}