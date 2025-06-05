package com.ecommerce.rustretail.enums;

import lombok.Getter;

@Getter
public enum AccountStatus {
    ACTIVE(1),
    INACTIVE(0);

    private final int value;

    AccountStatus(int value) {
        this.value = value;
    }
}
