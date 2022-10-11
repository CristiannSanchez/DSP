using Microsoft.EntityFrameworkCore;
using PStudent.BL.PagModelo;
using PStudent.DAL;
using PStudent.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PStudent.BL
{
    public class StudentService
    {
        private readonly DBContext studentDBContext;

        public StudentService(DBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }

        public async Task<DetalleDeContacto> GetStudentByIdAsync(int IdRegistro)
        {
            return await studentDBContext.Registros.Select(
                s => new DetalleDeContacto
                {
                    Id = s.Id,
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    FehcaDeNacimiento = (DateTime)s.FehcaDeNacimiento,
                    Email=s.Email,
                    Telefono = (int)s.Telefono
                }).FirstOrDefaultAsync(s => s.Id == IdRegistro);
        }

        public async Task<List<RegistroDeContactos>> GetAllStudentAsync()
        {
            return await studentDBContext.Registros.Select(
                s => new RegistroDeContactos
                {
                    Id = s.Id,
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    FehcaDeNacimiento = (DateTime)s.FehcaDeNacimiento,
                    Email = s.Email,
                    Telefono = (int)s.Telefono
                }).ToListAsync();
        }

        public async Task InsertStudentAsync(DetalleDeContacto student)
        {
            var entity = new Registro()
            {
                Id = student.Id,
                Nombres = student.Nombres,
                Apellidos = student.Apellidos,
                FehcaDeNacimiento = student.FehcaDeNacimiento,
                Email = student.Email,
                Telefono = student.Telefono
            };

            studentDBContext.Registros.Add(entity);
            await studentDBContext.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(DetalleDeContacto student)
        {
            var entity = await studentDBContext.Registros.FirstOrDefaultAsync(s=>s.Id == student.Id);

            entity.Nombres=student.Nombres;
            entity.Apellidos=student.Apellidos;
            entity.FehcaDeNacimiento=student.FehcaDeNacimiento;
            entity.Email = student.Email;
            entity.Telefono = student.Telefono;

            await studentDBContext.SaveChangesAsync();
        }

        public async Task DeleteContactoAsync(int IdRegistro)
        {
            var entity = new Registro()
            {
                Id = IdRegistro
            };

            studentDBContext.Registros.Attach(entity);
            studentDBContext.Registros.Remove(entity);

            await studentDBContext.SaveChangesAsync();
        }
    }
}
