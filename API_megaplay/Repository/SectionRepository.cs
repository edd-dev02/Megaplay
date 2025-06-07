using System;
using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Repository.IRepository;

namespace API_megaplay.Repository;

public class SectionRepository : ISectionRepository
{

    // Instancia del contexto
    private readonly ApplicationDbContext _db;

    public SectionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool SectionExists(int id)
    {
        return _db.Sections.Any(s => s.Id == id);
    }

    public bool SectionExists(string name)
    {
        return _db.Sections.Any(s => s.SectionName.ToLower().Trim() == name.ToLower().Trim());
    }

    public bool CreateSection(Section section)
    {
        section.CreationDate = DateTime.Now;
        _db.Sections.Add(section);
        return Save();
    }

    public bool DeleteSection(Section section)
    {
        _db.Sections.Remove(section);
        return Save();
    }

    public ICollection<Section> GetSections()
    {
        return _db.Sections.OrderBy(s => s.SectionName).ToList();
    }

    public Section? GetSection(int id)
    {
        return _db.Sections.FirstOrDefault(s => s.Id == id);
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }

    public bool UpdateSection(Section section)
    {
        section.CreationDate = DateTime.Now;
        _db.Sections.Update(section);
        return Save();
    }
}
