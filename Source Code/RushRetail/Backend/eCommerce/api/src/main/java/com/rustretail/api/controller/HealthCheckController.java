package com.rustretail.api.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Map;

@RestController
@RequestMapping("/health-check")
public class HealthCheckController {

    @GetMapping("")
    public Map<String, String> healthCheck() {
        return Map.of("message", "Hello, secured world!");
    }
}
