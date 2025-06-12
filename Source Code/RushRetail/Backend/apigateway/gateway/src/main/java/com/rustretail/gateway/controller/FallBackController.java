package com.rustretail.gateway.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

@RestController
@RequestMapping("/fallback")
public class FallBackController {

    @GetMapping("/identities")
    public Mono<String> identityServiceFallback() {
        return Mono.just("Identity Service is currently unavailable. Please try again later.");
    }

}
