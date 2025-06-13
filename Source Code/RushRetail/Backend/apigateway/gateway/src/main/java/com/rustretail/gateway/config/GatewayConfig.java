package com.rustretail.gateway.config;

import org.springframework.cloud.gateway.filter.ratelimit.KeyResolver;
import org.springframework.cloud.gateway.filter.ratelimit.RedisRateLimiter;
import org.springframework.cloud.gateway.route.RouteLocator;
import org.springframework.cloud.gateway.route.builder.RouteLocatorBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class GatewayConfig {

    /**
     * Configures the routing rules for the gateway. Each route defines a specific URI path,
     * applies associated filters such as circuit breakers, rate limiting, path rewriting, 
     * and adds custom headers before directing the request to the appropriate downstream service.
     *
     * @param builder the {@link RouteLocatorBuilder} used to construct the router configuration
     * @param redisRateLimiter the {@link RedisRateLimiter} used to limit request rates
     * @param keyResolver the {@link KeyResolver} used to determine the rate limit key (e.g., client IP)
     * @return the {@link RouteLocator} instance representing the configured routing rules
     */
    @Bean
    public RouteLocator routeLocator(RouteLocatorBuilder builder, RedisRateLimiter redisRateLimiter, KeyResolver keyResolver) {
        return builder.routes()
                //identity service
                .route(r -> r
                        .path("/api/{version}/identity/**")
                        .filters(f -> f
                                .circuitBreaker(config -> config
                                        .setName("identityServiceCircuitBreaker")
                                        .setFallbackUri("forward:/fallback/identities"))
                                .rewritePath("/api/identity/(?<segment>.*)", "/api/${version}/identity/${segment}")
                                .requestRateLimiter(config -> config
                                        .setRateLimiter(redisRateLimiter)
                                        .setKeyResolver(keyResolver))
                                .addRequestHeader("X-Gateway-Request", "true"))
                        .uri("lb://identity-service")
                )
                .route(r -> r
                        .path("api/{version}/user/**")
                        .filters(f -> f
                                .circuitBreaker(config -> config
                                        .setName("userServiceCircuitBreaker")
                                        .setFallbackUri("forward:/fallback/users"))
                                .rewritePath("/api/users/(?<segment>.*)", "/api/${version}/users/${segment}")
                                .requestRateLimiter(config -> config
                                        .setRateLimiter(redisRateLimiter)
                                        .setKeyResolver(keyResolver))
                                .addRequestHeader("X-Gateway-Request", "true"))
                        .uri("lb://user-service")
                )
                .build();
    }
}
