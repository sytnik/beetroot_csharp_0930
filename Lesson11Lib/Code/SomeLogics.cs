﻿namespace Lesson11Lib.Code;

public static class SomeLogics
{
    public static ConcreteEmployee SetupEmployee(int id)
    {
        var emp = new ConcreteEmployee();
        emp.Id = id;
        return emp;
    }
}