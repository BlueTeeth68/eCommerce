package com.ecommerce.rustretail.models.dto;

import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
public class BaseDto {
    private Long id;
    private Instant createdAt;
    private Instant updatedAt;
}
