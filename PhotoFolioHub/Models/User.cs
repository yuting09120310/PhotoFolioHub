using System;
using System.Collections.Generic;

namespace PhotoFolioHub.Models;

public partial class User
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Admin> Admins { get; } = new List<Admin>();

    public virtual ICollection<UserAlbum> UserAlbums { get; } = new List<UserAlbum>();

    public virtual ICollection<UserPhoto> UserPhotos { get; } = new List<UserPhoto>();
}
