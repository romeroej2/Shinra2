namespace ShinraCo.Spells.Main
{
    public class BasicClassSpells
    {
        public ArcanistSpells Arcanist { get; } = new ArcanistSpells();
        public ArcherSpells Archer { get; } = new ArcherSpells();
        public ConjurerSpells Conjurer { get; } = new ConjurerSpells();
        public GladiatorSpells Gladiator { get; } = new GladiatorSpells();
        public LancerSpells Lancer { get; } = new LancerSpells();
        public MarauderSpells Marauder { get; } = new MarauderSpells();
        public PugilistSpells Pugilist { get; } = new PugilistSpells();
        public RogueSpells Rogue { get; } = new RogueSpells();
        public ThaumaturgeSpells Thaumaturge { get; } = new ThaumaturgeSpells();
    }
}