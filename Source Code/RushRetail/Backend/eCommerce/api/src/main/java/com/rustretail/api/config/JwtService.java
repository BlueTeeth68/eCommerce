package com.rustretail.api.config;

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.io.Decoders;
import io.jsonwebtoken.security.Keys;

import javax.crypto.SecretKey;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;

public class JwtService {
    private final SecretKey secretKey;
    private final long accessExpirationMillis;
    private final long refreshExpirationMillis;

    public JwtService(String base64Secret, long accessExpirationMillis, long refreshExpirationMillis) {
        this.secretKey = Keys.hmacShaKeyFor(Decoders.BASE64.decode(base64Secret));
        this.accessExpirationMillis = accessExpirationMillis;
        this.refreshExpirationMillis = refreshExpirationMillis;
    }

    // Backwards-compatible method name, now explicitly generates ACCESS tokens
    public String generateToken(String username, Map<String, Object> extraClaims) {
        return generateAccessToken(username, extraClaims);
    }

    public String generateAccessToken(String username, Map<String, Object> extraClaims) {
        Map<String, Object> claims = new HashMap<>(extraClaims == null ? Map.of() : extraClaims);
        claims.putIfAbsent("typ", "access");
        return buildToken(username, claims, accessExpirationMillis);
    }

    public String generateRefreshToken(String username, Map<String, Object> extraClaims) {
        Map<String, Object> claims = new HashMap<>(extraClaims == null ? Map.of() : extraClaims);
        claims.put("typ", "refresh");
        return buildToken(username, claims, refreshExpirationMillis);
    }

    private String buildToken(String username, Map<String, Object> claims, long ttlMillis) {
        Date now = new Date();
        Date exp = new Date(now.getTime() + ttlMillis);
        return Jwts.builder()
                .setClaims(claims)
                .setSubject(username)
                .setIssuedAt(now)
                .setExpiration(exp)
                .signWith(secretKey, SignatureAlgorithm.HS256)
                .compact();
    }

    public String extractUsername(String token) {
        return extractClaim(token, Claims::getSubject);
    }

    public String extractType(String token) {
        return extractClaim(token, c -> (String) c.get("typ"));
    }

    public <T> T extractClaim(String token, Function<Claims, T> claimsResolver) {
        Claims claims = parseAllClaims(token);
        return claimsResolver.apply(claims);
    }

    public boolean isTokenValid(String token, String username) {
        return isTokenOfTypeValid(token, username, "access");
    }

    public boolean isRefreshTokenValid(String token, String username) {
        return isTokenOfTypeValid(token, username, "refresh");
    }

    private boolean isTokenOfTypeValid(String token, String username, String expectedType) {
        String subject = extractUsername(token);
        String type = extractType(token);
        return subject != null && subject.equals(username) && !isTokenExpired(token) && expectedType.equals(type);
    }

    private boolean isTokenExpired(String token) {
        Date expiration = extractClaim(token, Claims::getExpiration);
        return expiration.before(new Date());
    }

    private Claims parseAllClaims(String token) {
        return Jwts.parserBuilder()
                .setSigningKey(secretKey)
                .build()
                .parseClaimsJws(token)
                .getBody();
    }
}
