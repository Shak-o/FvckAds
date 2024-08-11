﻿using MediatR;

namespace FvckAds.Application.Rooms.Commands;

public class CreateRoomCommand : IRequest
{
    public required string RoomName { get; set; }
    public required List<string> Tags { get; set; }
}