package com.ecommerce.rustretail.enums;

import lombok.Getter;

@Getter
public enum CustomerStatus {
    ENABLE(1),
    DISABLE(0);

    private final int value;

    CustomerStatus(int value) {
        this.value = value;
    }
}
