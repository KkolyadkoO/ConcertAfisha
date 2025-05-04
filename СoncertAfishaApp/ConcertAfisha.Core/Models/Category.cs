namespace ConcertAfisha.Core.Models;

using System.ComponentModel;  

public enum Category
{
    [Description("Поп")]
    Pop,
    
    [Description("Рок")]
    Rock,
    
    [Description("Классическая")]
    Classical,
    
    [Description("Джаз")]
    Jazz,
    
    [Description("Мировая музыка")]
    WorldMusic,
    
    [Description("Хип-хоп")]
    HipHop,
    
    [Description("Электронная")]
    Electronic,
    
    [Description("Рэп")]
    Rap,
    
    [Description("Кантри")]
    Country,
    
    [Description("Рэгги")]
    Reggae
}