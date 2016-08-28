using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Email.Core.Models
{
    public class Template : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TemplateTranslation> Translations { get; set; }

        public byte[] Timestamp { get; set; }
    }

    public class TemplateTranslation : Translation
    {
        public Template Template { get; set; }
        public Guid TemplateId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
