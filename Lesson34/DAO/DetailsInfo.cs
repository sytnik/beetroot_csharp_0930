﻿namespace Lesson34.DAO;

public class DetailsInfo
{
    [Key] public int InfoId { get; set; }
    public string Data { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}