﻿namespace ConcertAfisha.Application.DTOs.Location;

public record LocationResponseDto(
    Guid Id,
    string Title,
    string Address,
    string City,
    double Lat,
    double Lng
);