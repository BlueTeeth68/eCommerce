package com.rustretail.gateway.config;

import io.github.resilience4j.timelimiter.TimeLimiterConfig;
import org.springframework.cloud.circuitbreaker.resilience4j.ReactiveResilience4JCircuitBreakerFactory;
import org.springframework.cloud.circuitbreaker.resilience4j.Resilience4JConfigBuilder;
import org.springframework.cloud.client.circuitbreaker.Customizer;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.time.Duration;

/**
 * Configuration class for Resilience4j Circuit Breaker.
 * This class configures the circuit breaker behavior for different services.
 */
@Configuration
public class CircuitBreakerConfig {

    /**
     * Configures the default circuit breaker settings for all services.
     * 
     * @return a customizer for the Resilience4J circuit breaker factory
     */
    @Bean
    public Customizer<ReactiveResilience4JCircuitBreakerFactory> defaultCustomizer() {
        return factory -> factory.configureDefault(id -> new Resilience4JConfigBuilder(id)
                .circuitBreakerConfig(io.github.resilience4j.circuitbreaker.CircuitBreakerConfig.custom()
                        .slidingWindowSize(10)
                        .failureRateThreshold(50)
                        .waitDurationInOpenState(Duration.ofSeconds(10))
                        .permittedNumberOfCallsInHalfOpenState(5)
                        .slowCallRateThreshold(50)
                        .slowCallDurationThreshold(Duration.ofSeconds(2))
                        .build())
                .timeLimiterConfig(TimeLimiterConfig.custom()
                        .timeoutDuration(Duration.ofSeconds(3))
                        .build())
                .build());
    }

    /**
     * Configures specific circuit breaker settings for the identity service.
     * 
     * @return a customizer for the identity service circuit breaker
     */
    @Bean
    public Customizer<ReactiveResilience4JCircuitBreakerFactory> identityServiceCustomizer() {
        return factory -> factory.configure(builder -> builder
                .circuitBreakerConfig(io.github.resilience4j.circuitbreaker.CircuitBreakerConfig.custom()
                        .slidingWindowSize(10)
                        .failureRateThreshold(40)
                        .waitDurationInOpenState(Duration.ofSeconds(5))
                        .permittedNumberOfCallsInHalfOpenState(3)
                        .slowCallRateThreshold(40)
                        .slowCallDurationThreshold(Duration.ofSeconds(1))
                        .build())
                .timeLimiterConfig(TimeLimiterConfig.custom()
                        .timeoutDuration(Duration.ofSeconds(2))
                        .build()), "identityServiceCircuitBreaker");
    }

    /**
     * Configures specific circuit breaker settings for the user service.
     * 
     * @return a customizer for the user service circuit breaker
     */
    @Bean
    public Customizer<ReactiveResilience4JCircuitBreakerFactory> userServiceCustomizer() {
        return factory -> factory.configure(builder -> builder
                .circuitBreakerConfig(io.github.resilience4j.circuitbreaker.CircuitBreakerConfig.custom()
                        .slidingWindowSize(10)
                        .failureRateThreshold(40)
                        .waitDurationInOpenState(Duration.ofSeconds(5))
                        .permittedNumberOfCallsInHalfOpenState(3)
                        .slowCallRateThreshold(40)
                        .slowCallDurationThreshold(Duration.ofSeconds(1))
                        .build())
                .timeLimiterConfig(TimeLimiterConfig.custom()
                        .timeoutDuration(Duration.ofSeconds(2))
                        .build()), "userServiceCircuitBreaker");
    }
}