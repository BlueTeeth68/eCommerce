package com.rustretail.gateway.controller;

import com.rustretail.gateway.controller.model.ApiResponse;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/health-check")
public class HealthCheck {

    @GetMapping()
    public ApiResponse<String> healthCheck() {
        return ApiResponse.<String>builder().build();
    }
}
