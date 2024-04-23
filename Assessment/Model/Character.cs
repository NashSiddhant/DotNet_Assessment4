using System.Formats.Asn1;

namespace Assessment.Model
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Frodo";

        public int HitPoint { get; set; } = 10;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Intelligence { get; set; } = 100;

        public RPGClass CharacterClass { get; set; } = RPGClass.Knight;
    }
}
