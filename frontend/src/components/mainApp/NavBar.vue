<template>
    <div class="navbar">
        <CalendarNavigator />
        <IconButton @click="handleLogoutClick" :elementStyle="InteractableElementLight" :icon="Icons.Gear"
            :tooltip="settingsTooltip" />
    </div>
</template>

<script setup lang="ts">
import IconButton from '../reusable/IconButton.vue';
import store from '../../store/store';
import { InteractableElementLight, ElementLight } from '../../models/style/Styles';
import { Icons } from '../../models/icons/Icons';
import { Tooltip } from '../../store/TooltipState';
import { Anchor } from '../../models/geometry/Anchor';
import CalendarNavigator from './CalendarNavigator.vue';

const handleLogoutClick = () => {
    // store.actions.setUserToLoggedOut()
}

const settingsTooltip: Tooltip = {
    content: "Open settings",
    shortcut: "Ctrl+S",
    anchor: Anchor.Southeast, 
    style: ElementLight
}

</script>

<style scoped>
.navbar {
    padding: 10px;
    background-color: black;
    display: flex;
    color: white;
    justify-content: space-between; 
}
</style>