using System;
using System.Collections.Generic;

namespace PhotoFolioHub.Models;

public partial class AlbumPhoto
{
    public long AlbumPhotoId { get; set; }

    public long? AlbumId { get; set; }

    public long? PhotoId { get; set; }

    public virtual UserAlbum? Album { get; set; }

    public virtual UserPhoto? Photo { get; set; }
}
