using MessagePack;
using System.Numerics;

namespace TSDBAOBAB_server {
    public enum Character : int {
        BG72,
        SG27,
    }
    [MessagePackObject]
    public class PlayerNetworkObject {
        [Key(0)]
        public float[] Position { get; set; }
        [Key(1)]
        public float[] Rotation { get; set; }
        [Key(2)]
        public Character Character { get; set; }
        [Key(3)]
        public int Id { get; set; }
        [Key(4)]
        public float[] Velocity { get; set; }
        public PlayerLocalObject ToLocal() {
            return new PlayerLocalObject {
                Position = Position.ToVector3(),
                Rotation = Rotation.ToQuaternion(),
                Character = Character,
                Id = Id,
                Velocity = Velocity.ToVector3()
            };
        }
    }
    public class PlayerLocalObject {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Character Character { get; set; }
        public int Id { get; set; }
        public Vector3 Velocity { get; set; }
        public PlayerNetworkObject ToNetwork() {
            return new PlayerNetworkObject {
                Position = Position.ToFloatArray(),
                Rotation = Rotation.ToFloatArray(),
                Character = Character,
                Id = Id,
                Velocity = Velocity.ToFloatArray()
            };
        }
    }
    [MessagePackObject]
    public class GameObject {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public float[] Position { get; set; }
        [Key(2)]
        public float[] Rotation { get; set; }
    }
    [MessagePackObject]
    public class PhysicsGameObject : GameObject {
        [Key(3)]
        public float[] Velocity { get; set; }
        [Key(4)]
        public float[] AngularVelocity { get; set; }
        [Key(5)]
        public int RigidbodyConstraints { get; set; }
    }
    [MessagePackObject]
    public class LineGameObject : GameObject {
        [Key(3)]
        public float[] Position1 { get; set; }
        [Key(4)]
        public float[] Position2 { get; set; }
    }
}
