using System;

namespace signalRAh.Domain.Entities
{
    public class AggregateRoot
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }


    }


    public class SickPersionEntity : AggregateRoot
    {
        public SickPersionEntity(string name, string persionId, string room, string state)
        {
            Id = new System.Guid();
            Name = name;
            PersionId = persionId;
            Room = room;
            State = state;
        }

        public string Name { get; set; }
        public string PersionId { get; set; }
        public string Room { get; set; }
        public string State { get; set; }

    }
    public class SickPersion
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string PersionId { get; set; }
        public string Room { get; set; }
        public string State
        {
            get; set;
        }
    }
}