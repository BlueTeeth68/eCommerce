package com.ecommerce.rustretail.enums;

import lombok.Getter;

@Getter
public enum UserStatus {
    ACTIVE(1), INACTIVE(0);

    private final int value;

    UserStatus(int value) {
        this.value = value;
    }
}
