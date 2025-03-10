﻿namespace Application.Dtos;

public sealed record GetFilterProductPageDto(
    ICollection<ProductDto> Products,
    int TotalCount,
    int TotalPage
    );
