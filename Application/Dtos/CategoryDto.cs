﻿namespace Application.Dtos;

public sealed record CategoryDto(int Id, string Name, ICollection<ProductDto> ProductDtos);
