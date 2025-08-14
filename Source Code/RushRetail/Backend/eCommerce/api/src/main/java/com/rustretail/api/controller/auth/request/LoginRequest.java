package com.rustretail.api.controller.auth.request;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;
import lombok.Getter;

public record LoginRequest(
        @NotBlank @Email String username,
        @NotBlank @Size(min = 6, max = 100) String password
) {
}
