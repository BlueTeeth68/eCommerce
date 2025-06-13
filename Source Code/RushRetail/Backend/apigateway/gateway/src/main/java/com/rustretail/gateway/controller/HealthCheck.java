package com.rustretail.gateway.controller;

import com.rustretail.gateway.controller.model.ApiResponse;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

@RestController
@RequestMapping("/health-check")
public class HealthCheck {

    @GetMapping()
    public Mono<ApiResponse<String>> healthCheck() {
        return Mono.just(ApiResponse.<String>builder()
                .data("OK")
                .success(true)
                .build());
    }
}
