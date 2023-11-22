<template>
    <div class="dropdown">
        <slot></slot>
        <transition name="dropdown">
            <div :style="getAlignment()" class="dropdown-content" v-if="showDropdown">
                <slot name="dropdown-content"></slot>
            </div>
        </transition>
    </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';

const props = defineProps({
    showDropdown: {
        type: Boolean,
    },
    horizontalAlignment: {
        type: String
    }
});

const getAlignment = () => {
    if (props.horizontalAlignment == "right") {
        return {
            right: 0
        }
    } else {
        return {
            left: 0
        }
    }
}

const showDropdown = ref(false)
const isInitialClick = ref(true)

const emit = defineEmits(["clickOutside"])
const handleClickOutside = (event: Event) => {
    const target = event.target as HTMLElement;
    const dropdownContent = document.querySelector('.dropdown-content')

    const clickIsInsideDropdownContent = dropdownContent.contains(target)

    if (!clickIsInsideDropdownContent && !isInitialClick.value) {
        emit("clickOutside")
    }

    isInitialClick.value = false
};

// Conscious decision to have dropdown state be controlled from outside. Some 
// dropdowns will want this behaviour (i.e panning between different year selectors)
watch(() => props.showDropdown, (value) => {
    isInitialClick.value = true
    if (value) {
        handleShowDropdown()
    }
    else {
        handleHideDropdown()
    }
});

const handleShowDropdown = () => {
    showDropdown.value = true
    document.addEventListener('click', handleClickOutside);
}

const handleHideDropdown = () => {
    showDropdown.value = false
    document.removeEventListener('click', handleClickOutside);
}
</script>

<style scoped>
.dropdown {
    position: relative;
}

.dropdown-content {
    position: absolute;
}


.dropdown-enter-active,
.dropdown-leave-active {
    transition: opacity 0.1s ease, transform 0.1s;
}

.dropdown-enter-from,
.dropdown-leave-to {
    opacity: 0;
    transform: translateY(-4px);
}
</style>