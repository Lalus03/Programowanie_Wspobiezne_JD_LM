using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DataContract]
    internal record struct CollisionRecord
    {
        [DataMember]
        public int BallId { get; set; }
        [DataMember]
        public int? OtherBallId { get; set; } 
        [DataMember]
        public string CollisionType { get; set; } 
        [DataMember]
        public Vector2 Position { get; set; }
        [DataMember]
        public DateTime Time { get; set; }

        public CollisionRecord(int ballId, int? otherBallId, string collisionType, Vector2 position, DateTime time)
        {
            BallId = ballId;
            OtherBallId = otherBallId;
            CollisionType = collisionType;
            Position = position;
            Time = time;
        }
    }
}
