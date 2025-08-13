package com.rustretail.gateway.controller;

import com.rustretail.gateway.controller.model.ApiResponse;
import com.rustretail.gateway.controller.model.ErrorResponse;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

import java.time.Instant;

@RestController
@RequestMapping("/fallback")
public class FallBackController {

    @GetMapping("identities")
    public Mono<ApiResponse<Object>> identityServiceFallback() {
        ApiResponse<Object> response = ApiResponse.builder()
                .success(false)
                .error(ErrorResponse.builder()
                        .status(HttpStatus.SERVICE_UNAVAILABLE)
                        .title("Service unavailable")
                        .detail("Identity Service is currently unavailable. Please try again later.")
                        .timestamp(Instant.now())
                        .build())
                .build();
        return Mono.just(response);
    }

    @GetMapping("ecom")
    public Mono<ApiResponse<Object>> ecomServiceFallBack() {
        ApiResponse<Object> response = ApiResponse.builder()
                .success(false)
                .error(ErrorResponse.builder()
                        .status(HttpStatus.SERVICE_UNAVAILABLE)
                        .title("Service unavailable")
                        .detail("Ecom Service is currently unavailable. Please try again later.")
                        .timestamp(Instant.now())
                        .build())
                .build();
        return Mono.just(response);
    }
}
