namespace Crimsonland
{
    using Microsoft.Xna.Framework;

    public class Camera
    {
        public Camera()
        {
            Zoom = 1f;
        }

        // Centered Position of the Camera in pixels.
        public Vector2 Position { get; private set; }
        public float Zoom { get; private set; }
        public float Rotation { get; private set; }

        // Height and width of the viewport window which should be adjusted when the player resizes the game window.
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        // Center of the Viewport does not account for scale
        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }

        // create a matrix for the camera to offset everything we draw, the map and our objects. since the
        // camera coordinates are where the camera is, we offset everything by the negative of that to simulate
        // a camera moving. we also cast to integers to avoid filtering artifacts
        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                   Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        public void MoveCamera(Vector2 cameraMovement, bool clampToMap = false)
        {
            Vector2 newPosition = Position + cameraMovement;

            if (clampToMap)
            {
                Position = MapClampedPosition(newPosition);
            }
            else
            {
                Position = newPosition;
            }
        }

        // Center the camera on specific pixel coordinates
        public void CenterOn(Vector2 position)
        {
            Position = position;
        }

        // Clamp the camera so it never leaves the visible area of the map.
        private Vector2 MapClampedPosition(Vector2 position)
        {
            var cameraMax = new Vector2(Global.MapWidth * Global.SpriteWidth - (ViewportWidth / Zoom / 2),
            Global.MapHeight * Global.SpriteHeight - (ViewportHeight / Zoom / 2));

            return Vector2.Clamp(position, new Vector2(ViewportWidth / Zoom / 2, ViewportHeight / Zoom / 2), cameraMax);
        }
    }
}
