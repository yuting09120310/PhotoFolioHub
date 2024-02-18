using System;
using System.Collections.Generic;

namespace PhotoFolioHub.Models;

public partial class UserPhoto
{
    public long PhotoId { get; set; }

    public long? UserId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? UploadDateTime { get; set; }

    public bool? IsApproved { get; set; }

    public virtual ICollection<AlbumPhoto> AlbumPhotos { get; } = new List<AlbumPhoto>();

    public virtual User? User { get; set; }
}
