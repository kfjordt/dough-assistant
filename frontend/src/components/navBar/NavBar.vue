<template>
    <div :style="{ backgroundColor: navBarStyle.main.background }" class="navbar">
        <CalendarNavigator />
        <NavBarHeader />
    </div>
</template>

<script setup lang="ts">
import CalendarNavigator from './CalendarNavigator.vue';
import IconButton from '../reusable/IconButton.vue';
import { computed } from '@vue/reactivity';
import { useStyleStore } from '../../stores/style';
import NavBarHeader from './NavBarHeader.vue';
import Dropdown from '../reusable/Dropdown.vue';
import { Icons } from '../../models/icons/Icons';

const navBarStyle = computed(() => useStyleStore().sectionStyles.navBar)
</script>

<style scoped>
.navbar {
    padding: 4px;
    display: flex;
    height: 40px;
    justify-content: space-between;
    color: grey
}
</style>