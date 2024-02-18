using System;
using System.Collections.Generic;

namespace PhotoFolioHub.Models;

public partial class UserAlbum
{
    public long AlbumId { get; set; }

    public long? UserId { get; set; }

    public string AlbumName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AlbumPhoto> AlbumPhotos { get; } = new List<AlbumPhoto>();

    public virtual User? User { get; set; }
}
