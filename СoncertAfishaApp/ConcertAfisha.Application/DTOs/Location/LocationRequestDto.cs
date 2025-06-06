﻿namespace ConcertAfisha.Application.DTOs.Location;

public record LocationRequestDto(
    string Title,
    string Address,
    string City,
    double Lat,
    double Lng
    );