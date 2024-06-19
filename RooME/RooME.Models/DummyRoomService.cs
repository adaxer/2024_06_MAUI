namespace RooME.Models;

public class DummyRoomService
{
	public static async Task<IEnumerable<Room>> GetRoomsAsync()
	{
		await Task.Delay(1000); 
        return new List<Room>
        {
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Executive Boardroom",
                Description = "A spacious room with a large conference table and premium chairs.",
                Location = "Building A, Floor 5"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Creative Space",
                Description = "A room designed for brainstorming with whiteboards and comfortable seating.",
                Location = "Building B, Floor 2"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Virtual Conference Room",
                Description = "Equipped with advanced video conferencing equipment.",
                Location = "Building C, Floor 1"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Small Meeting Room",
                Description = "A compact room for small team meetings.",
                Location = "Building D, Floor 3"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Training Room",
                Description = "A room equipped with projectors and seating for training sessions.",
                Location = "Building E, Floor 4"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Client Meeting Room",
                Description = "A professional setting for meetings with clients.",
                Location = "Building F, Floor 6"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Huddle Room",
                Description = "A small, private room for quick huddles and discussions.",
                Location = "Building G, Floor 2"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Presentation Room",
                Description = "A room with presentation facilities and tiered seating.",
                Location = "Building H, Floor 5"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Workshop Room",
                Description = "A room designed for workshops and collaborative work.",
                Location = "Building I, Floor 3"
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Name = "Project Room",
                Description = "A room for project teams to collaborate on ongoing projects.",
                Location = "Building J, Floor 1"
            }
        };
	}
}
