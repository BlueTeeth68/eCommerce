package com.rustretail.gateway.config;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.gateway.filter.ratelimit.KeyResolver;
import org.springframework.cloud.gateway.filter.ratelimit.RedisRateLimiter;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import reactor.core.publisher.Mono;

import java.util.Objects;

@Configuration
public class RateLimiterConfig {

    @Value("${spring.cloud.gateway.redis-rate-limiter.replenish-rate}")
    private int replenishRate;
    @Value("${spring.cloud.gateway.redis-rate-limiter.burst-capability}")
    private int burstCapacity;
    @Value("${spring.cloud.gateway.redis-rate-limiter.requested-tokens}")
    private int requestedTokens;

    /**
     * Provides a KeyResolver bean that extracts the client's IP address from the incoming
     * exchange request. This IP address is used as the unique key for managing rate-limiting
     * policies in a gateway application.
     *
     * @return a KeyResolver that resolves the client's IP address for rate-limiting purposes
     */
    @Bean
    public KeyResolver keyResolver() {
        return exchange -> {
            String clientIp = Objects.requireNonNull(exchange.getRequest().getRemoteAddress()).getAddress().getHostAddress();
            return Mono.just(clientIp);
        };
    }

    /**
     * Provides a Redis-based implementation of a rate limiter, configured with default
     * values for replenish rate, burst capacity, and request capacity. This bean is used
     * to limit the rate of requests to the underlying services.
     *
     * @return a RedisRateLimiter instance configured with the specified default settings
     */
    @Bean
    public RedisRateLimiter redisRateLimiter() {
        return new RedisRateLimiter(replenishRate, burstCapacity, requestedTokens);
    }
}
