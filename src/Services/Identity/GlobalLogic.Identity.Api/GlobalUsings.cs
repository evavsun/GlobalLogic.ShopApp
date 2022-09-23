global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;

global using GlobalLogic.Identity.Api.Abstractions.Identity;
global using GlobalLogic.Identity.Api.Models;
global using GlobalLogic.Identity.Api.Abstractions.Repositories;
global using GlobalLogic.Identity.Api.Entities;
global using GlobalLogic.Identity.Api.DAL.EF;
global using GlobalLogic.Identity.Api.Services;
global using GlobalLogic.Identity.Api.DAL.Respositories;
global using GlobalLogic.Identity.Api.Exceptions;
