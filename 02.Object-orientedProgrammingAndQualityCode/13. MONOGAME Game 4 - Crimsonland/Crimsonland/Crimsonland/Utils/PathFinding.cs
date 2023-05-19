namespace Crimsonland
{
    using RogueSharp;

    public class PathFinding
    {
        private readonly Player player;
        private readonly IMap map;
        private readonly PathFinder pathFinder;
        private Path path;

        public PathFinding(Player player, IMap map)
        {
            this.player = player;
            this.map = map;
            pathFinder = new PathFinder(map);
        }

        public Cell FirstCell
        {
            get
            {
                return path.Start;
            }
        }

        public Cell NextStep
        {
            get
            {
                if(path.End != path.CurrentStep)
                {
                    return path.StepForward();
                }
                return path.CurrentStep;
            }
        }

        public void CreateFrom(int x, int y)
        {
            path = pathFinder.ShortestPath(map.GetCell(x, y), map.GetCell(player.X, player.Y));
        }
    }
}
