﻿namespace SOAproject.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string UserName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}