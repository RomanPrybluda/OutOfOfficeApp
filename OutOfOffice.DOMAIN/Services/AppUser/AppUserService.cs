﻿using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserService
    {
        private readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUserDTO>> GetAppUsersAsync()
        {
            var appUsers = await _context.AppUsers.ToListAsync();

            if (appUsers == null)
                throw new CustomException(CustomExceptionType.NotFound, "AppUsers weren't found");

            var appUserDTOs = new List<AppUserDTO>();

            foreach (var appUser in appUsers)
            {
                var appUserDTO = AppUserDTO.AppUserToAppUserDTO(appUser);
                appUserDTOs.Add(appUserDTO);
            }

            return appUserDTOs;
        }

        public async Task<AppUserByIdDTO> GetAppUserByIdAsync(Guid id)
        {
            var appUsersById = await _context.AppUsers.FirstOrDefaultAsync(e => e.Id == id);

            if (appUsersById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"AppUser with id {id} wasn't found.");

            var appUserByIdDTO = AppUserByIdDTO.AppUserToAppUserDTO(appUsersById);

            return appUserByIdDTO;
        }

        public async Task<AppUserDTO> CreateAppUserAsync(CreateAppUserDTO request)
        {
            var existingUser = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
                throw new CustomException(CustomExceptionType.UserIsAlreadyExists,
                    $"AppUser with email {request.Email} already exists.");


            var role = await _context.Roles.FindAsync(request.RoleId);

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Role with id '{request.RoleId}' wasn't found.");


            var appUser = CreateAppUserDTO.CreateAppUserDTOToAppUser(request);

            _context.AppUsers.Add(appUser);

            await _context.SaveChangesAsync();

            var createdUser = await _context.AppUsers.FindAsync(appUser.Id);

            var appUserDTO = AppUserDTO.AppUserToAppUserDTO(createdUser);

            return appUserDTO;
        }

        public async Task<AppUserDTO> UpdateAppUserAsync(Guid id, UpdateAppUserDTO request)
        {
            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"AppUser with id {id} wasn't found.");


            var role = await _context.Roles.FindAsync(request.RoleId);

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Role with id '{request.RoleId}' wasn't found.");


            UpdateAppUserDTO.UpdateAppUser(appUser, request);

            await _context.SaveChangesAsync();

            var updatedUserDTO = AppUserDTO.AppUserToAppUserDTO(appUser);

            return updatedUserDTO;
        }

        public async Task DeleteAppUserAsync(Guid id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"AppUser with id {id} wasn't found.");


            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();
        }

    }
}
