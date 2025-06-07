using System;
using API_megaplay.Models;

namespace API_megaplay.Repository.IRepository;

public interface ISectionRepository
{

    ICollection<Section> GetSections();
    Section? GetSection(int id);
    bool SectionExists(int id);
    bool SectionExists(string name);

    bool CreateSection(Section section);
    bool UpdateSection(Section section);
    bool DeleteSection(Section section);
    bool Save();

}
