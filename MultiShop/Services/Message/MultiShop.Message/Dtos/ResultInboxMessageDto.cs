﻿namespace MultiShop.Message.Dtos
{
    public class ResultInboxMessageDto
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool isRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
